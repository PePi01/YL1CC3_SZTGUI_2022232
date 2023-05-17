let cars = [];
let brands = [];
let rents = [];
let connection = null;
let carid = -1;
let brandid = -1;
let rentid = -1;
SetupSignalR();

GetData();

function SetupSignalR() {
    
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:10237/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("CarCreated", (user, message) => {
        GetData();
    });

    connection.on("CarDeleted", (user, message) => {
        GetData();
    });
    connection.on("CarUpdated", (user, message) => {
        GetData();
    });


    connection.on("BrandCreated", (user, message) => {
        GetData();
    });
    connection.on("BrandDeleted", (user, message) => {
        GetData();
    });
    connection.on("BrandUpdated", (user, message) => {
        GetData();
    });

    connection.on("RentCreated", (user, message) => {
        GetData();
    });
    connection.on("RentDeleted", (user, message) => {
        GetData();
    });
    connection.on("RentUpdated", (user, message) => {
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
            GenerateBrand();
            //BrandShowBrand();
        });
    await fetch('http://localhost:10237/car')
        .then(x => x.json())
        .then(y => {
            console.log(y)
            cars = y;
            GenerateCar();
        });
    await fetch('http://localhost:10237/rent')
        .then(x => x.json())
        .then(y => {
            console.log(y)
            rents = y;
            GenerateRent();
        });
}


/* START OF CAR SECTION */
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
            //GetData();
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
            //GetData();
        })
        .catch((error) => { console.error('Error:', error); });
}
function ModifyCar() {
    let model = document.getElementById('modelmod').value;
    let brandid = document.getElementById('brandidmod').value;
    let price = document.getElementById('pricemod').value;

    fetch('http://localhost:10237/car/' , {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { id:carid, model: model, brandid: brandid, price: price }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            //GetData();
        })
        .catch((error) => { console.error('Error:', error); });
    document.getElementById('modifycar').style.display = 'none';
}
function ShowModify(id) {
    carid = id;
    document.getElementById('modelmod').value = cars.find(t => t.id == id).model;
    document.getElementById('brandidmod').value = cars.find(t => t.id == id).brandId;
    document.getElementById('pricemod').value = cars.find(t => t.id == id).price;
    document.getElementById('modifycar').style.display = 'flex';
    
} function Carpage() {
    document.getElementById('carpage').style.display = 'flex';
    document.getElementById('brandpage').style.display = 'none';
    document.getElementById('rentpage').style.display = 'none';
    document.getElementById('modifybrand').style.display = 'none';
    document.getElementById('modifyrent').style.display = 'none';
}
/*END OF CAR SECTION */

/* START OF BRAND SECTION */
function GenerateBrand() {
    document.getElementById('brandbody').innerHTML = '';
    brands.forEach(t => {
        document.getElementById('brandbody').innerHTML +=
            "<tr>" +
            `<td>${t.id}</td>` +
            `<td>${t.name}</td>` +
            `<td><button type="button" onclick="DeleteBrand(${t.id})">Delete</button>` +
            `<button type="button" onclick="ShowModifyBrand(${t.id})">Modify</button></td>` +
            "</tr>";
    });
}
function BrandShowBrand() {/*nem kell sztem*/

    document.getElementById('brandshowbrand').innerHTML += '';
    document.getElementById('brandshowbrand').style.display = 'flex';
    brands.forEach(t => {
        document.getElementById('brandshowbrand').innerHTML +=
            "<tr>" +
            `<td>${t.id}</td>` +
            `<td>${t.name}</td>` +
            "</tr>";
    })
}

function CreateBrand() {
    let brandname = document.getElementById('brandname').value;


    fetch('http://localhost:10237/brand', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { name: brandname }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            //GetData();
        })
        .catch((error) => { console.error('Error:', error); });


}
function DeleteBrand(id) {
    fetch('http://localhost:10237/brand/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            //GetData();
        })
        .catch((error) => { console.error('Error:', error); });
}

function ModifyBrand() {
    let brandmod = document.getElementById('brandmod').value;


    fetch('http://localhost:10237/brand/', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { id: brandid, name: brandmod }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            //GetData();
        })
        .catch((error) => { console.error('Error:', error); });

    document.getElementById('modifybrand').style.display = 'none';
}
function ShowModifyBrand(id) {
    brandid = id;
    document.getElementById('brandmod').value = brands.find(t => t.id == id).name;
    document.getElementById('modifybrand').style.display = 'flex';
}
function Brandpage() {
    document.getElementById('rentpage').style.display = 'none';
    document.getElementById('brandpage').style.display = 'flex';
    document.getElementById('brandcreate').style.display = 'flex';
    //document.getElementById('modifybrand').style.display = 'flex';
    document.getElementById('carpage').style.display = 'none';
    document.getElementById('rentpage').style.display = 'none';
    document.getElementById('modifyrent').style.display = 'none';
    document.getElementById('modifycar').style.display = 'none';
}

//START OF RENT SECTION 

function GenerateRent() {
    document.getElementById('rentbody').innerHTML = '';
    rents.forEach(t => {
        document.getElementById('rentbody').innerHTML +=
            "<tr>" +
            `<td>${t.id}</td>` +
            `<td>${t.carId}</td>` +
            `<td>${t.start}</td>` +
            `<td>${t.end}</td>` +
            `<td><button type="button" onclick="DeleteRent(${t.id})">Delete</button>` +
        `<button type="button" onclick="ShowModifyRent(${t.id})">Modify</button></td>` +
            "</tr>";
    });
    ShowModelId();
}
function CreateRent() {
    let starttime = document.getElementById('starttime').value;
    let endtime = document.getElementById('endtime').value;
    let carid = document.getElementById('idmodel').value;


    fetch('http://localhost:10237/rent', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { carid:carid ,start: starttime, end:endtime }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            //GetData();
        })
        .catch((error) => { console.error('Error:', error); });


}

function DeleteRent(id) {
    fetch('http://localhost:10237/rent/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            //GetData();
        })
        .catch((error) => { console.error('Error:', error); });
}
function ShowModelId() {
    document.getElementById('carmodel').innerHTML = '';

    cars.forEach(t => {
        document.getElementById('carmodel').innerHTML +=

            "<tr>" +
            `<td>${t.id} → ${t.model}</td>` +

            "</tr>";
    })
}

function ModifyRent() {
    let start = document.getElementById('starttimemod').value;
    let end = document.getElementById('starttimemod').value;


    fetch('http://localhost:10237/rent/', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { id: rentid, start: start, end:end }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            //GetData();
        })
        .catch((error) => { console.error('Error:', error); });

    document.getElementById('modifyrent').style.display = 'none';
}
function ShowModifyRent(id) {
    rentid = id;
    document.getElementById('idmodelmod').value = rents.find(t => t.id == id).carId;
    document.getElementById('starttimemod').value = rents.find(t => t.id == id).start;
    document.getElementById('endtimemod').value = rents.find(t => t.id == id).end;
    document.getElementById('modifyrent').style.display = 'flex';
    //document.getElementById('modifyrent').style.flexDirection = 'column';
}

function RentPage() {
    document.getElementById('brandpage').style.display = 'none';
    document.getElementById('carpage').style.display = 'none';
    document.getElementById('modifybrand').style.display = 'none';
    document.getElementById('modifycar').style.display = 'none';
    document.getElementById('rentpage').style.display = 'block';
    document.getElementById('rentcreate').style.display = 'block';
    //document.getElementById('modifyrent').style.display = 'block';
    document.getElementById('renttabla').style.display = 'block';
}