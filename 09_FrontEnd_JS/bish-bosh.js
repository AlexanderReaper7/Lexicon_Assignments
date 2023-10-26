function bishBosh(length, bish, bosh) {
    var out = '';
    if (length < 1 || bish < 1 || bosh < 1) {
        return 'Error: all numbers must be greater than 0';
    }
    for (let i = 1; i <= length; i++) {
        if (i % bish === 0 && i % bosh === 0) {
            out += 'Bish-Bosh ';
        } else if (i % bish === 0) {
            out += 'Bish ';
        } else if (i % bosh === 0) {
            out += 'Bosh ';
        } else {
            out += i + ' ';
        }
    }
    return out;
}

function run() {
    let length = document.getElementById("length").value
    let bish = document.getElementById("bish").value
    let bosh = document.getElementById("bosh").value
    history.pushState({}, '', '?length=' + length + '&bish=' + bish + '&bosh=' + bosh);
    document.getElementById('output').innerHTML=bishBosh(length, bish, bosh)
}

const urlParams = new URLSearchParams(window.location.search)
const length = urlParams.get('length')
const bish = urlParams.get('bish')
const bosh = urlParams.get('bosh')
if (length != null && bish != null && bosh != null) {
    document.getElementById('output').innerHTML = bishBosh(length, bish, bosh);
}