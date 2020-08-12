appContext.view.add('main', function () {
    const time = appContext.model.inputs.weatherRecommendation.time;
    document.getElementById('app').innerHTML = `
<h1> Logg inn her :) </h1> 
</br>
</br>
<div class="UserName" id="userBoxTxt"> Brukernavn </div>
<input class="InsertUsername" type="text" id="usernameInput" placeholder="Brukernavn">
<button class="loginButton" onclick="login()">Logg inn</div></button>
 </br> </br>
<a href="javascript:goTo('newUser')">Registrer ny bruker her!</a>
`;
});
function login() {
    goTo('userLoggedIn');
    }
