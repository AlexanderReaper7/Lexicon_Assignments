namespace BishBosh {
    function bishBosh(length: number, bish: number, bosh: number): string {
        let out = '';
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

    export function run(): void {
        const length = Number((<HTMLInputElement>document.getElementById('length'))?.value);
        const bish = Number((<HTMLInputElement>document.getElementById('bish'))?.value);
        const bosh = Number((<HTMLInputElement>document.getElementById('bosh'))?.value);
        if (length && bish && bosh) {
            history.pushState({}, '', `?length=${length}&bish=${bish}&bosh=${bosh}`);
            document.getElementById('output')!.innerHTML = bishBosh(length, bish, bosh);
        }
    }

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
}