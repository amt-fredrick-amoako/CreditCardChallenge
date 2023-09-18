window.updateCardNumber = (inputElement) => {
    let cardNumber = inputElement.value;
    let maskedNumber = '';

    for (let i = 0; i < cardNumber.length; i++) {
        maskedNumber += cardNumber[i] === ' ' || i < 4 ? cardNumber[i] : '#';
    }

    inputElement.value = maskedNumber;
    console.log("Js running")
};
