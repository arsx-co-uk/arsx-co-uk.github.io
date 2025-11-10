// MetaMask detection and provider handling
if (typeof window.ethereum !== 'undefined') {
    console.log('MetaMask is detected.');

    // Prevent reinitialization of the provider
    if (!window.ethereum.isInitialized) {
        window.ethereum.isInitialized = true;
        console.log('Provider initialized successfully.');
    } else {
        console.log('Provider already initialized. Skipping initialization.');
    }
} else {
    console.log('MetaMask is not detected.');
}