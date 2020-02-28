const cards = document.querySelectorAll('.memory-card');
let hasFlipperdCard = false;
let lockBoard = false;
let firstCard, secondCard;
var cont =0;
var aciertos=0;
function flipCard(){
    
    if(lockBoard)return;
    if(this === firstCard)return;

    this.classList.add('flip');

    if(!hasFlipperdCard){
        //primer clic
        hasFlipperdCard=true;
        firstCard=this;

       return;
    }
        //segundo clic
        secondCard=this;
        checkForMatch();
    
}
function checkForMatch(){
    let isMatch=firstCard.dataset.framework === secondCard.dataset.framework;
       isMatch ? disableCards(): unflipCards();
       cont++;
       score();
       winGame();
 }

 function disableCards(){//desactivar carta
    firstCard.removeEventListener('click',flipCard);
    secondCard.removeEventListener('click',flipCard);
    aciertos++;
    console.log(aciertos);
    resetBoard();
 }

 function unflipCards(){
    lockBoard = true;
        
      setTimeout(()=>{
             firstCard.classList.remove('flip');
             secondCard.classList.remove('flip');
             resetBoard();
        },900);
        
 }
 function resetBoard(){//reiniciar tablero
     [hasFlipperdCard,lockBoard] = [false,false];
     [firstCard,secondCard]=[null,null];
    
 }
 (function shuffle (){
     cards.forEach(card =>{
        let randomPosition = Math.floor(Math.random()* 18);
        card.style.order = randomPosition;
     });
 })();

 function score(){
     document.getElementById('score').innerHTML=cont;
 }
 function winGame(){
     if(cards == 9){
         alert("Haz ganado");
     }
 }

cards.forEach(card => card.addEventListener('click',flipCard));