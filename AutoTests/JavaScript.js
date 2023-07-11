document.addEventListener("DOMContentLoaded", function () {
    const loginForm = document.getElementById("login-form");

    loginForm.addEventListener("submit", function (event) {
        event.preventDefault();
        const username = document.getElementById("username").value;
        const password = document.getElementById("password").value;
        const isAuthorized = TestAuthorization(username, password);

        if (isAuthorized) {
            result.textContent = "Авторизація успішна";
            result.style.color = "#4caf50";
            //window.location.href = 'file:///D:/%23-VS/AutoTests/tests.html';
        } else {
            result.textContent = "Помилка авторизації";
            result.style.color = "#e67e22";
        }
    });
});

function TestAuthorization(username, password) {
    const savedUsername = "1";
    const savedPassword = "2";

    return username === savedUsername && password === savedPassword;
}