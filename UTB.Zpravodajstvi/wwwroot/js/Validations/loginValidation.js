document.addEventListener("DOMContentLoaded", function() {
    const form = document.querySelector('.form-signin');
    
    form.addEventListener('submit', function(event) {
        let isValid = true;
        const username = document.getElementById('inputUsername').value;
        const password = document.getElementById('inputPassword').value;

        if (username.trim() === "") {
            isValid = false;
            alert("Uživatelské jméno nesmí být prázdné.");
        }

        if (password.trim() === "") {
            isValid = false;
            alert("Heslo nesmí být prázdné.");
        }

        if (!isValid) {
            event.preventDefault();
        }
    });
});