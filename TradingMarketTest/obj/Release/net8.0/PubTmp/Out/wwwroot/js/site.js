document.getElementById('loginForm').addEventListener('submit', function (event) {
    event.preventDefault();

    const email = document.getElementById('email').value;
    const password = document.getElementById('password').value;
    const rememberMe = document.getElementById('remember-me').checked;

    // Here you should add the AJAX request or fetch API call to your backend
    console.log('Attempting login with:', email, password, rememberMe);

    // This is where you'd actually submit the data to your server
    // For example using Fetch API:
    // fetch('/login', {
    //   method: 'POST',
    //   headers: {
    //     'Content-Type': 'application/json'
    //   },
    //   body: JSON.stringify({ email, password, rememberMe })
    // })
    // .then(response => response.json())
    // .then(data => {
    //   // handle response data
    // })
    // .catch((error) => {
    //   console.error('Error:', error);
    // });
});

function createAccount() {
    window.location.href = '/register';
    // Redirects user to the account creation page
}
