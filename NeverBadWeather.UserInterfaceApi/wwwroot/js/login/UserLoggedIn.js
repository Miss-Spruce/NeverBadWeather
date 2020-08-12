appContext.view.add('userLoggedIn', function () {
    const time = appContext.model.inputs.weatherRecommendation.time;
    document.getElementById('app').innerHTML = `

    <small><a href="javascript:goTo('rules')">Rediger klesinnstillingene</a></small>

    <hr/>

    <h3>Aldri dårlig vær!</h3>

</br>
</br>

<div class="LocationForm">
     <form action="/action_page.php">
     <label for="location">Hvor er du?</label>
     <select name="location" id="location">
     <option value="larvik">Larvik</option>
     <option value="tønsberg">Tønsberg</option>
     <option value="sandefjord">Sandefjord</option>
     <option value="horten">Horten</option>
     </select>
     <br><br>
     <button class="velgstedKnapp" onclick="VelgeSted()" type="submit">Velg!</button>
     </form></div>
     </br>
     </br>

        Hvilken dag vil du ha klesråd for? <br/>
        <input type="date" oninput="appContext.model.date = this.value" value="${time.date}"/><br/>
        Hvilken tidsperiode?<br/>
        Fra  
        <span class="timeStepUpDown" onclick="changeTime('from',-1)">▼</span
        ><span class="timeStepUpDown">kl. ${time.from}</span
        ><span class="timeStepUpDown" onclick="changeTime('from',+1)">▲</span>
        til 
        <span class="timeStepUpDown" onclick="changeTime('to',-1)">▼</span
        ><span class="timeStepUpDown">kl. ${time.to}</span
        ><span class="timeStepUpDown" onclick="changeTime('to',+1)">▲</span>
        <br/>

        <button class="klesanbefalingKnapp" onclick="getClothingRecommendation()">Få klesanbefaling!</button>

        ${getRecommendationHtml()}
`;
});

function getRecommendationHtml() {
    const recommendation = appContext.model.recommendation;
    if (recommendation === null) return '';
    const rules = recommendation.rules;
    const place = recommendation.place;
    const weatherForecast = recommendation.weatherForecast;

    return `
        <h4>Klesanbefaling for ${place}</h4>
        <table>
            <tr>
                <th>Fra</th>
                <th>Til</th>
                <th>Værtype</th>
                <th>Klær</th>
            </tr>
            ${rules.map((rule, i) => `
            <tr>
                <td>${rule.fromTemperature}°C</td>
                <td>${rule.toTemperature}°C</td>
                <td>${weatherTypeText(rule.isRaining)}</td>
                <td>${rule.clothes}</td>
            </tr>
            `).join('')}
        </table>
        Dette er basert på følgende værmelding: 
        <ul>
            ${weatherForecast.map(f => `
                <li>${f}</li>
            `).join('')}
        </ul>

    `;
}

function VelgeSted() {

    //denne skal da føre deg til stedet du har valgt
    // - Larvik
    //https://www.yr.no/stad/Noreg/Vestfold_og_Telemark/Larvik/varsel.xml  ny link ? 
    // - Tønsberg
    //https://www.yr.no/stad/Noreg/Vestfold_og_Telemark/Tønsberg/varsel.xml  ny link ? 
    // - Sandefjord
    //https://www.yr.no/stad/Noreg/Vestfold_og_Telemark/Sandefjord/varsel.xml
    // - Horten
    //https://www.yr.no/stad/Noreg/Vestfold_og_Telemark/Horten/varsel.xml
}