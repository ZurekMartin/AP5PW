document.addEventListener("DOMContentLoaded", function() {
    const form = document.querySelector('.form-signup');
    
    form.addEventListener('submit', function(event) {
        let isValid = true;
        const password = document.getElementById('user-pass').value;
        const repeatedPassword = document.getElementById('user-repeatpass').value;

        if (password !== repeatedPassword) {
            isValid = false;
            alert("Hesla se neshodují.");
        }

        const passwordPattern = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/;
        if (!passwordPattern.test(password)) {
            isValid = false;
            alert("Heslo musí obsahovat alespoň 8 znaků, velké a malé písmeno, číslici a speciální znak.");
        }

        if (!isValid) {
            event.preventDefault();
        }
    });
});