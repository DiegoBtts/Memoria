
var cont = 0;
var aciertos=0;
var EntrarBtn = 0;
var primeraCarta = true;


window.onload = iniciarJuego;

function iniciarJuego(){
    const cards = document.querySelectorAll('.memory-card');
  let hasFlipperdCard = false;
  let lockBoard = false;
  let firstCard, secondCard;
  init();


    cards.forEach(card => card.addEventListener('click',flipCard)); 
    if(aciertos==0){
      shuffle();
  } 
  
    function flipCard() {// voltea cartas
        play('Clic');
    if(primeraCarta==true){
      console.log("Entro al if de carta")
      console.log(primeraCarta);
      primeraCarta = false;
        
      iniciar();
      
    }
      if(lockBoard)return;    
      if(this === firstCard)return;
      this.classList.add('flip');
      if(!hasFlipperdCard){
           console.log("esta en el metodo flipCard")
          //primer clic
          hasFlipperdCard=true;
          firstCard=this;
          
         return;
      }
          //segundo clic
          secondCard=this;
         
          cont++;
          console.log("Score:"+cont);
          checkForMatch();  
          
      
  }

  function checkForMatch(){//compara 
      let isMatch=firstCard.dataset.framework === secondCard.dataset.framework;
         isMatch ? disableCards(): unflipCards();
         score();
        
         console.log("entro al metodo CheckForMatch")
        
   }

    function disableCards() {//desactivar carta
      play('Varita');
      console.log("entro al metodo disableCards")
      firstCard.removeEventListener('click',flipCard);
      secondCard.removeEventListener('click',flipCard);
      aciertos++;
      console.log("aciertos:"+aciertos)
       resetBoard();
       
      winGame();
   }
  
    function unflipCards() {//ocultar carta
        play('Quack');
       console.log("entro al metodo unFlipCards")
       
      lockBoard = true;  
        setTimeout(()=>{
               firstCard.classList.remove('flip');
               secondCard.classList.remove('flip');
               resetBoard();
          },900);
          
   }
   function resetBoard(){//reiniciar cartas
      console.log("entro al metodo resetBoard");
       [hasFlipperdCard,lockBoard] = [false,false];
       [firstCard,secondCard]=[null,null];
       
   }
   function shuffle (){//barajear carta
      console.log("entro al metodo shuffle")
       cards.forEach(card =>{
          let randomPosition = Math.floor(Math.random()* 20);//aqui menie era 18
          card.style.order = randomPosition;
         
       });
      }
  
   function score(){//intentos
       document.getElementById('score').innerHTML=cont;

   }
  
   function winGame(){
       if(aciertos==(cards.length/2)){
           alert("Felicidades haz ganado")
          parar();
       }
   }
}
 
  
   function reiniciar(){
       console.log("entro al metodo reiniciar");
       reiniciarCronometro();
      // document.getElementById('recargar').reload(true);
     location.reload(true);
    
   }

   function generarTablero(images){
    
    var Apps = ['instagram', 'whatssap', 'messenger', 'facebook', 'apple', 'firefox', 'android', 'java', 'photos', 'drive'];
    var zonaDeJuego = document.createElement('section'); //Se crea un div para ingresar el html dinámico
    zonaDeJuego.id = "tablero";

    var tablero = '<section class=\"memory-game\">'; //Inicio de la lista
 

   for(var i=1; i<=10; i++){
     
  
        console.log('entro al if de apps');
       tablero+= "<div class=\"memory-card\" data-framework=\""+Apps[i-1]+"\"><img class=\"front-face\" src=\"img/MemoriaJuego/"+Apps[i-1]+".png\"><img class=\"back-face\" src=\"img/MemoriaJuego/question.png\"></div>"; //Se concatenan cada uno de los hijos en la variable html
        tablero+= "<div class=\"memory-card\" data-framework=\""+Apps[i-1]+"\"><img class=\"front-face\" src=\"img/MemoriaJuego/"+Apps[i-1]+".png\"><img class=\"back-face\" src=\"img/question.png\"></div>";  
     
    
   }

 tablero+= '</section>'; //Fin de la lista

zonaDeJuego.innerHTML = tablero; //Se agrega el html dinámico al div contenedor "padre"


var pagina = document.getElementById('todo');
pagina.appendChild(zonaDeJuego);
//Se agrega el div contenedor "padre" al div contenedor "página"
iniciarJuego();
}

function play(name) {
    var audio = document.getElementById(name);
    audio.play();
}
 