// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener('DOMContentLoaded', function () {
    // Vyhledávání
    const searchInput = document.getElementById('searchInput');
    const searchButton = document.getElementById('searchButton');

    function performSearch() {
        const searchTerm = searchInput.value.toLowerCase();
        const articles = document.querySelectorAll('.article-card');
        
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

    // Původní kód pro filtrování
    function filterArticles(categoryId = null, tagId = null) {
        const articles = document.querySelectorAll('.article-card');
        const mainArticle = document.querySelector('.featured-article');

        // Reset vyhledávání
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

            if (showArticle) {
                article.style.display = ''; 
            } else {
                article.style.display = 'none'; 
            }
        });
    }

    document.querySelector('.tag-button[data-filter="all"]').addEventListener('click', function () {
        filterArticles(); 
    });

    const categoryButtons = document.querySelectorAll('.tag-button[data-category]');
    categoryButtons.forEach(button => {
        button.addEventListener('click', function () {
            const categoryId = button.getAttribute('data-category');
            
            const activeTagButton = document.querySelector('.tag-button.active[data-tag]');
            if (activeTagButton) {
                activeTagButton.classList.remove('active');
            }

            filterArticles(categoryId);
            categoryButtons.forEach(btn => btn.classList.remove('active'));
            button.classList.add('active');
        });
    });

    const tagButtons = document.querySelectorAll('.tag-button[data-tag]');
    tagButtons.forEach(button => {
        button.addEventListener('click', function () {
            const tagId = button.getAttribute('data-tag');
            
            const activeCategoryButton = document.querySelector('.tag-button.active[data-category]');
            if (activeCategoryButton) {
                activeCategoryButton.classList.remove('active');
            }
            filterArticles(null, tagId);
            tagButtons.forEach(btn => btn.classList.remove('active'));
            button.classList.add('active');
        });
    });
});
