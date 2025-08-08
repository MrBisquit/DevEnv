let scanning = {};

(async () => {
    console.log("%cDevEnv", "color: #E240F1; font-size:5rem; font-weight: bolder;");
    console.log("Use \"search(\"ID of IDE/PLC/FWK\");\" to search, visit documentation: https://github.com/MrBisquit/DevEnv/blob/master/docs/Scanning.md");

    try {
        const response = await fetch("/scanning");
        if(!response.ok) {
            document.body.innerHTML = "<span>Failed to fetch scanning list, please refresh the page to try again.</span>";
        }

        scanning = await response.json();
    } catch {
        document.body.innerHTML = "<span>Failed to fetch scanning list, please refresh the page to try again.</span>";
    }

    setTimeout(() => {
        document.getElementById("search-box").addEventListener("keyup", (event) => {
            search(document.getElementById("search-box").value);
        });
    }, 1);
})();

const search = (id) => {
    console.log(scanning);
}