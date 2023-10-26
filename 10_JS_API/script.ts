// Star Wars Biometrics ---------------------------------------------------------------
const swUri = "https://www.swapi.tech/api/people/?name=";

function getApiStarWars() {
    const input = document.getElementById("sw-input") as HTMLInputElement;

    if (input !== null) {
        const inputValue = input.value;
        if (inputValue === "") {
            return;
        }
        fetch(swUri + inputValue)
            .then(res => res.json())
            .then(data => {
                if (data.result.length !== 0) {
                    displayData(data);
                } else {
                    const output = document.getElementById("sw-output") as HTMLInputElement;
                    output.value = "No results found";
                }
            })
            .catch(err => console.warn(err));

    } else {
        console.warn("Input is null");
    }
}

function displayData(data: any) {
    const output = document.getElementById("sw-output") as HTMLInputElement;

    if (output !== null) {
        const props = data.result[0].properties;
        const name = props.name;
        const height = props.height;
        const mass = props.mass;
        const hairColor = props.hair_color;
        const eyeColor = props.eye_color;
        const gender = props.gender;
        output.value = `Name: ${name}\nHeight: ${height}\nMass: ${mass}\nHair Color: ${hairColor}\nEye Color: ${eyeColor}\nGender: ${gender}`;
    } else {
        console.warn("Output is null");
    }
}

function hookUpButton(id: string, func: any) {
    const button = document.getElementById(id);

    if (button !== null) {
        button.addEventListener("click", func);
    } else {
        console.warn("Button is null");
    }
}


// Draw a card ---------------------------------------------------------------
let deckId = "";
let cardsRemaining = 0;
function drawCard() {
    // check if we already have a deck and there are cards remaining
    if (deckId !== "" && cardsRemaining > 0) {
        // draw a card from the deck
        fetch(`https://deckofcardsapi.com/api/deck/${deckId}/draw/?count=1`)
            .then(res => res.json())
            .then(data => showCard(data))
            .catch(err => console.warn(err));
    } else {
        // draw a card from a new deck and save the deck id
        fetch("https://deckofcardsapi.com/api/deck/new/draw/?count=1")
            .then(res => res.json())
            .then(data => {
                deckId = data.deck_id;
                console.log("New deck: " + deckId);
                showCard(data);
            })
            .catch(err => console.warn(err));
    }
}

function showCard(data: any) {
    cardsRemaining = data.remaining;
    const cardDescription = data.cards[0].value + " of " + data.cards[0].suit;
    const cardDescElem = document.getElementById("card-desc") as HTMLInputElement;
    cardDescElem.innerHTML = cardDescription;
    const cardRemElem = document.getElementById("card-remaining") as HTMLInputElement;
    cardRemElem.innerHTML = cardsRemaining.toString();
    const imgUrl = data.cards[0].images.svg
    const cardImgElem = document.getElementById("card-img") as HTMLImageElement;
    cardImgElem.hidden = false;
    cardImgElem.src = imgUrl;
    cardImgElem.alt = cardDescription;
}

// Main ---------------------------------------------------------------
(async () => {
    await new Promise(f => setTimeout(f, 100));
    hookUpButton("sw-btn", getApiStarWars);
    hookUpButton("card-btn", drawCard);
})();
