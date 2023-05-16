let cars = [];
let brands = [];
let rents = [];
let connection = null;
let carid = -1;
SetupSignalR();

GetData();

function SetupSignalR() {
    
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:10237/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("CarCreated", (user, message) => {
        GetData();
        console.log("fasztudja");
    });

    connection.on("CarDeleted", (user, message) => {
        GetData();
    });
    connection.on("CarUpdated", (user, message) => {
        GetData();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
}
async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        console.log("faszomat");
        setTimeout(start, 5000);
    }
}

async function GetData() {
    await fetch('http://localhost:10237/brand')
        .then(x => x.json())
        .then(y => {
            console.log(y)
            brands = y;
            ShowBrand();
            ShowBrandMod();
        });
    await fetch('http://localhost:10237/car')
        .then(x => x.json())
        .then(y => {
            console.log(y)
            cars = y;
            GenerateCar();
        });
}

function ShowBrand() {
    document.getElementById('brandshow').innerHTML = '';
    brands.forEach(t => {
        document.getElementById('brandshow').innerHTML +=
            "<tr>" +
        `<td>${t.name} → ${t.id}</td>` +
            "</tr>";
    });
}
function ShowBrandMod() {
    document.getElementById('brandshowmod').innerHTML = '';
    brands.forEach(t => {
        document.getElementById('brandshowmod').innerHTML +=
            "<tr>" +
        `<td>${t.name} →  ${t.id}</td>` +
            "</tr>";
    });
}

function GenerateCar() {
    document.getElementById('carbody').innerHTML = '';
    cars.forEach(t => {
        document.getElementById('carbody').innerHTML +=
        "<tr>" +
            `<td>${t.id}</td>` +
            `<td>${t.model}</td>` +
            `<td>${t.price}</td>` +
        `<td><button type="button" onclick="DeleteCar(${t.id})">Delete</button>` +
            `<button type="button" onclick="ShowModify(${t.id})">Modify</button></td>` +
        "</tr>";
    });
}

function CreateCar() {
    let model = document.getElementById('model').value;
    let brandid = document.getElementById('brandid').value;
    let price = document.getElementById('price').value;

    fetch('http://localhost:10237/car', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { model: model,brandid:brandid,price:price }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            GetData();
        })
        .catch((error) => { console.error('Error:', error); });
}
function DeleteCar(id) {
    fetch('http://localhost:10237/car/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            GetData();
        })
        .catch((error) => { console.error('Error:', error); });
}
function ModifyCar() {
    let model = document.getElementById('modelmod').value;
    let brandid = document.getElementById('brandidmod').value;
    let price = document.getElementById('pricemod').value;
    let kaki = null;

    fetch('http://localhost:10237/car/' , {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { id:carid, model: model, brandid: brandid, price: price }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            GetData();
        })
        .catch((error) => { console.error('Error:', error); });
}
function ShowModify(id) {
    carid = id;
    document.getElementById('modelmod').value = cars.find(t => t.id == id).model;
    document.getElementById('brandidmod').value = cars.find(t => t.id == id).brandId;
    document.getElementById('pricemod').value = cars.find(t => t.id == id).price;
    document.getElementById('modifycar').style.display = 'flex';
    
}