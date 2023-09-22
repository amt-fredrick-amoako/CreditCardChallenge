window.formatCardNumber = (inputValue) => {
    const cleanedInput = inputValue.replace(/\D/g, ''); // Remove non-digit characters
    const formattedInput = cleanedInput.replace(/(\d{4})/g, '$1 '); // Add a space every four digits
    return formattedInput.trim(); // Remove trailing space if any
};
