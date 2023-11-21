
function waitForElm(selector) {
    return new Promise(resolve => {
        if (document.querySelector(selector)) {
            return resolve(document.querySelector(selector));
        }

        const observer = new MutationObserver(mutations => {
            if (document.querySelector(selector)) {
                observer.disconnect();
                resolve(document.querySelector(selector));
            }
        });

        observer.observe(document.body, {
            childList: true,
            subtree: true
        });
    });
}

//To use
waitForElm('.some-class').then((elm) => {
    console.log('Element is ready');
    console.log(elm.textContent);
});

//To use 2
const elm = await waitForElm('.some-class');
