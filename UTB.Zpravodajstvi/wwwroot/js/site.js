// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let searchTimeout;

function debounceSearch(func, wait) {
    clearTimeout(searchTimeout);
    searchTimeout = setTimeout(func, wait);
}

document.addEventListener('DOMContentLoaded', function () {
    const searchInput = document.getElementById('searchInput');
    const searchButton = document.getElementById('searchButton');

    function resetFilters() {
        document.querySelectorAll('.tag-button').forEach(button => {
            button.classList.remove('active');
        });
        const allButton = document.querySelector('.tag-button[data-filter="all"]');
        if (allButton) {
            allButton.classList.add('active');
        }
    }

    function performSearch() {
        const searchTerm = searchInput.value.toLowerCase();
        const articles = document.querySelectorAll('.article-card');
        
        resetFilters();
        
        articles.forEach(article => {
            const title = article.querySelector('.card-title').textContent.toLowerCase();
            const description = article.querySelector('.card-text').textContent.toLowerCase();
            
            if (title.includes(searchTerm) || description.includes(searchTerm)) {
                article.style.display = '';
            } else {
                article.style.display = 'none';
            }
        });
    }

    if (searchInput && searchButton) {
        searchButton.addEventListener('click', performSearch);
        searchInput.addEventListener('keypress', function(e) {
            if (e.key === 'Enter') {
                performSearch();
            }
        });
    }

    function filterArticles(categoryId = null, tagId = null) {
        const articles = document.querySelectorAll('.article-card');
        const mainArticle = document.querySelector('.featured-article');

        if (searchInput) {
            searchInput.value = '';
        }

        if (mainArticle) {
            const mainArticleCategoryId = mainArticle.getAttribute('data-category');
            const mainArticleTags = mainArticle.getAttribute('data-tags') ? mainArticle.getAttribute('data-tags').split(',') : [];
            let showMainArticle = true;

            if (categoryId && mainArticleCategoryId !== categoryId) {
                showMainArticle = false;
            }

            if (tagId && !mainArticleTags.includes(tagId.toString())) {
                showMainArticle = false;
            }

            mainArticle.style.display = showMainArticle ? '' : 'none';
        }

        articles.forEach(article => {
            const articleCategoryId = article.getAttribute('data-category');
            const articleTags = article.getAttribute('data-tags') ? article.getAttribute('data-tags').split(',') : [];

            let showArticle = true;

            if (categoryId && articleCategoryId !== categoryId) {
                showArticle = false;
            }

            if (tagId && !articleTags.includes(tagId.toString())) {
                showArticle = false;
            }

            article.style.display = showArticle ? '' : 'none';
        });
    }

    document.querySelector('.tag-button[data-filter="all"]')?.addEventListener('click', function () {
        resetFilters();
        this.classList.add('active');
        filterArticles();
    });

    document.querySelectorAll('.tag-button[data-category]').forEach(button => {
        button.addEventListener('click', function () {
            const categoryId = this.getAttribute('data-category');
            
            if (searchInput) {
                searchInput.value = '';
            }
            
            document.querySelectorAll('.tag-button').forEach(btn => {
                btn.classList.remove('active');
            });
            
            this.classList.add('active');
            filterArticles(categoryId);
        });
    });

    document.querySelectorAll('.tag-button[data-tag]').forEach(button => {
        button.addEventListener('click', function () {
            const tagId = this.getAttribute('data-tag');
            
            if (searchInput) {
                searchInput.value = '';
            }
            
            document.querySelectorAll('.tag-button').forEach(btn => {
                btn.classList.remove('active');
            });
            
            this.classList.add('active');
            filterArticles(null, tagId);
        });
    });

    if (searchInput) {
        searchInput.addEventListener('input', function() {
            debounceSearch(() => performSearch(), 300);
        });
    }
});
