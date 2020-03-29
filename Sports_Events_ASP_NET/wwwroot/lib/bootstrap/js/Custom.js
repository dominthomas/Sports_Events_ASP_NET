function standby(elementID) {
    document.getElementById(elementID).src = '/images/users/empty.jpg'
}

function showPass() {
    var x = document.getElementById("userPassword");
    if (x.type === "password") {
        x.type = "text";
    } else {
        x.type = "password";
    }
}
