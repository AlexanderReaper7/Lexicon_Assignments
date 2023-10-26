"use strict";
var BishBosh;
(function (BishBosh) {
    function bishBosh(length, bish, bosh) {
        let out = '';
        for (let i = 1; i <= length; i++) {
            if (i % bish === 0 && i % bosh === 0) {
                out += 'Bish-Bosh ';
            }
            else if (i % bish === 0) {
                out += 'Bish ';
            }
            else if (i % bosh === 0) {
                out += 'Bosh ';
            }
            else {
                out += i + ' ';
            }
        }
        return out;
    }
    function run() {
        var _a, _b, _c;
        const length = Number((_a = document.getElementById('length')) === null || _a === void 0 ? void 0 : _a.value);
        const bish = Number((_b = document.getElementById('bish')) === null || _b === void 0 ? void 0 : _b.value);
        const bosh = Number((_c = document.getElementById('bosh')) === null || _c === void 0 ? void 0 : _c.value);
        if (length && bish && bosh) {
            history.pushState({}, '', `?length=${length}&bish=${bish}&bosh=${bosh}`);
            document.getElementById('output').innerHTML = bishBosh(length, bish, bosh);
        }
    }
    BishBosh.run = run;
    const runBtn = document.getElementById("runBtn");
    if (runBtn) {
        runBtn.addEventListener("click", run);
    }
    const urlParams = new URLSearchParams(window.location.search);
    const length = urlParams.get('length');
    const bish = urlParams.get('bish');
    const bosh = urlParams.get('bosh');
    if (length != null && bish != null && bosh != null) {
        const outputElement = document.getElementById('output');
        if (outputElement != null) {
            outputElement.innerHTML = bishBosh(Number(length), Number(bish), Number(bosh));
        }
    }
})(BishBosh || (BishBosh = {}));
