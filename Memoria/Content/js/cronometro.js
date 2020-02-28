window.onload = init;
function init(){
    console.log("Entro auiqen")
    hrs = 0;
    min = 0;
    seg = 0;
    document.getElementById("hms").innerHTML="00:00:00";
}         

function escribir(){
    var hrsAux, minAux, segAux;
    seg++;
    if (seg>59){
        min++;seg=0;
    }
    if (min>59){
        hrs++;min=0;
    }
    if (hrs>24){
        hrs=0;
    }

    if (seg<10){
        segAux="0"+seg;
    }else{
        segAux=seg;
    }
    if (min<10){
        minAux="0"+min;
    }else{
        minAux=min;
    }
    if (hrs<10){
        hrsAux="0"+hrs;
    }else{
        hrsAux=hrs;
    }

    document.getElementById("hms").innerHTML = hrsAux + ":" + minAux + ":" + segAux; 
}

function iniciar(){
    escribir();
    id = setInterval(escribir,1000);
}

function parar(){
    clearInterval(id);

}

function reiniciarCronometro(){
    clearInterval(id);
    document.getElementById("hms").innerHTML="00:00:00";
    hrs=0;min=0;seg=0;
}