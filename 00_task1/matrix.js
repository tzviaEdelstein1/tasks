
var tobody = document.getElementById('tobody');
function createTable() {
    tobody = document.getElementById('tobody');
    tobody.innerHTML = "";
    let tr;
   
var length =4;
    for (i = 0; i < length; i++) {
        tobody.innerHTML += `<tr id="r${i}"></tr>`
        tr = document.getElementById("r" + i);
        tr.innerHTML = "";
        for (j = 0; j < length; j++) {
            tr.innerHTML += `<td></td>`
        }
    }
}
function border() {

    let length=4;
    tobody = document.getElementById('tobody');
    for (i = 0; i< length; i++) {
        for (j = 0; j < length; j++) {
            tobody.children[i].children[j].classList.remove("gradient");
            if (i == 0 || j == 0 || i == length - 1 || j == length - 1) {
                tobody.children[i].children[j].classList.add("gradient");

            }



        }
    }
}
function upperPart() {
 
    let length=4;
    tobody = document.getElementById('tobody');
    for (i = 0; i< length; i++) {
        for (j = 0; j < length; j++) {
            tobody.children[i].children[j].classList.remove("gradient");
            if (i == j || i<j) {
                tobody.children[i].children[j].classList.add("gradient");

            }



        }
    }
}
function Diagonals() {
   
    let length=4;
    tobody = document.getElementById('tobody');
    for (i = 0; i< length; i++) {
        for (j = 0; j < length; j++) {
            tobody.children[i].children[j].classList.remove("gradient");
            if (i == j || i +j==length-1 ) {
                tobody.children[i].children[j].classList.add("gradient");
               
            }



        }
    }
}
function downPart() {
   
    let length=4;
    tobody = document.getElementById('tobody');
    for (i = 0; i< length; i++) {
        for (j = 0; j < length; j++) {
            tobody.children[i].children[j].classList.remove("gradient");
            if (i == j|| i >j ) {
                tobody.children[i].children[j].classList.add("gradient");

            }



        }
    }
}

