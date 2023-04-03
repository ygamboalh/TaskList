export function Toggle(divH)
{
    var div = document.getElementById(divH);
    if (div.style.display == "none") {
        div.style.display = "block";
    }
    else {
        div.style.display = "none";
    }
}
