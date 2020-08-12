appContext.view.add('newUser', function () {
    document.getElementById('app').innerHTML =
        `
</br>
</br>
<div class="UserName" id="userBoxTxt">Skriv ditt brukernavn her </div>
<input class="InsertUsername" type="text" id="usernameInput" placeholder="Brukernavn">
<button class="loginButton" onclick="login()">Lag bruker</div></button>
</br></br>

<a href="javascript:goTo('main')">tilbake til start!</a>


<button class="tilbakeStart" onclick="tilbake()">Tilbake til logg inn siden</button></div>
    `;


    function tilbake() {
        goTo('main');
    }
    function login() {
        goTo('userLoggedIn');
    }


});