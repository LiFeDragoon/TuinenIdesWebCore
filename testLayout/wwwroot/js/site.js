function setCookie(name, value, days) {
    var expires = "";
    if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        expires = "; expires=" + date.toUTCString();
    }
    document.cookie = name + "=" + (value || "") + expires + "; path=/";
}

function getCookie(name) {
    var nameEQ = name + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
    }
    return null;
}

function acceptCookies() {
    setCookie("cookiesAccepted", true, 7);
    hideBanner();

}

function declineCookies() {
    setCookie("cookiesAccepted", false, 7);
    hideBanner();
}

function hideBanner() {
    var banner = document.querySelector(".cookie-banner");
    if (banner) {
        banner.style.display = "none";
    }
}

document.addEventListener("DOMContentLoaded", function () {
    var cookiesAccepted = getCookie("cookiesAccepted");
    if (cookiesAccepted !== null) {
        hideBanner();
    }

    var acceptButton = document.querySelector(".accept");
    var declineButton = document.querySelector(".decline");

    // Check if acceptButton and declineButton are found before adding event listeners
    if (acceptButton) {
        acceptButton.addEventListener("click", acceptCookies);
    }

    if (declineButton) {
        declineButton.addEventListener("click", declineCookies);
    }
});
