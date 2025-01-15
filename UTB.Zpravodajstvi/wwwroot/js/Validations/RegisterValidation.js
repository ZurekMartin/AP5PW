$.validator.addMethod('strongpassword', function(value, element) {
    if (!value) return true;
    const hasLength = value.length >= 8;
    const hasUpper = /[A-Z]/.test(value);
    const hasLower = /[a-z]/.test(value);
    const hasNumber = /[0-9]/.test(value);
    
    return hasLength && hasUpper && hasLower && hasNumber;
});

$.validator.addMethod('czechphone', function(value, element) {
    if (!value) return true;
    return /^(\+420)?\s?[1-9][0-9]{2}\s?[0-9]{3}\s?[0-9]{3}$/.test(value);
});

$.validator.addMethod('validusername', function(value, element) {
    if (!value) return true;
    return /^[a-zA-Z0-9_-]+$/.test(value);
});

$.validator.unobtrusive.adapters.addBool('strongpassword');
$.validator.unobtrusive.adapters.addBool('czechphone');
$.validator.unobtrusive.adapters.addBool('validusername');

document.addEventListener('DOMContentLoaded', function() {
    const passwordInput = document.querySelector('input[name="Password"]');
    const strengthIndicator = document.getElementById('password-strength');
    const requirementsList = document.getElementById('password-requirements');

    if (passwordInput) {
        passwordInput.addEventListener('input', function() {
            const value = this.value;
            const requirements = {
                length: value.length >= 8,
                lowercase: /[a-z]/.test(value),
                uppercase: /[A-Z]/.test(value),
                number: /[0-9]/.test(value)
            };

            requirementsList.innerHTML = `
                <li class="${requirements.length ? 'text-success' : 'text-danger'}">
                    <i class="fas ${requirements.length ? 'fa-check' : 'fa-times'} me-2"></i>
                    Minimálně 8 znaků
                </li>
                <li class="${requirements.lowercase ? 'text-success' : 'text-danger'}">
                    <i class="fas ${requirements.lowercase ? 'fa-check' : 'fa-times'} me-2"></i>
                    Alespoň jedno malé písmeno
                </li>
                <li class="${requirements.uppercase ? 'text-success' : 'text-danger'}">
                    <i class="fas ${requirements.uppercase ? 'fa-check' : 'fa-times'} me-2"></i>
                    Alespoň jedno velké písmeno
                </li>
                <li class="${requirements.number ? 'text-success' : 'text-danger'}">
                    <i class="fas ${requirements.number ? 'fa-check' : 'fa-times'} me-2"></i>
                    Alespoň jedna číslice
                </li>
            `;

            const metRequirements = Object.values(requirements).filter(Boolean).length;
            let strength = 'Slabé';
            let strengthClass = 'text-danger';
            
            if (metRequirements === 4) {
                strength = 'Silné';
                strengthClass = 'text-success';
            } else if (metRequirements >= 2) {
                strength = 'Střední';
                strengthClass = 'text-warning';
            }

            strengthIndicator.innerHTML = `
                <i class="fas fa-shield-alt me-2"></i>
                Síla hesla: <span class="${strengthClass}">${strength}</span>
            `;
        });
    }
}); 