appContext.view.add('login', function () {
    document.getElementById('app').innerHTML =
        `
</br>
</br>
<div class="UserName" id="userBoxTxt"> Brukernavn </div>
<input class="InsertUsername" type="text" id="usernameInput" placeholder="Brukernavn">
<button class="loginButton" onclick="login()">Logg inn</div></button>
 
<a href="javascript:goTo('newUser')">Registrer ny bruker her!</a>
    `;
});
    
 