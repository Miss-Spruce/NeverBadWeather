appContext.view.add('login', function () {
    document.getElementById('app').innerHTML =
        `
<h1> Logg inn her :) </h1> 
</br>
</br>
<div class="UserName" id="userBoxTxt"> Brukernavn </div>
<input class="InsertUsername" type="text" id="usernameInput" placeholder="Brukernavn">
<a href="javascript:goTo('UserLoggedIn')">Logg inn</a>
 
<a href="javascript:goTo('newUser')">Registrer ny bruker her!</a>
    `;

    //function login() {
    //   return UserLoggedIn;
    //}
    function toUserProfile() {
        return mainPage;
    }
});
    
 