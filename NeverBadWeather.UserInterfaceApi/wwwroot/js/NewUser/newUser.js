appContext.view.add('newUser', function () {
    document.getElementById('app').innerHTML =
        `
</br>
</br>
<div class="UserName" id="userBoxTxt">Skriv ditt brukernavn her </div>
<input class="InsertUsername" type="text" id="usernameInput" placeholder="Brukernavn">
</br></br>
<button class="loginButton" onclick="login()">Lag bruker</div></button>
</br></br>

</br> </br>
<button class="tilbakeStart" onclick="tilbake()">Tilbake til logg inn siden</button></div>
    `;

});
    function tilbake() {
        goTo('main');
    }

    // denne er midlertidig frem til jeg har fikset database, da skal denne lage ny bruker i DB. 
    function login() {
        goTo('userLoggedIn');
    }


