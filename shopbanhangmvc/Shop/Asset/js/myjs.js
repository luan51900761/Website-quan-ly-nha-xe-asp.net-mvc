
var check = function () {
            if (document.getElementById('password').value ==
                document.getElementById('confirm_password').value) {
        document.getElementById('message').style.color = 'green';
                document.getElementById('message').innerHTML = 'password is matching';
                document.getElementById('message').innerHTML = 'password is matching';
                document.getElementById('btn-create').removeAttribute('disabled');

            } else {
        document.getElementById('message').style.color = 'red';
                document.getElementById('message').innerHTML = 'password is not matching';
                document.getElementById('btn-create').setAttribute('disabled', 'false');
            }
}

var CheckEdit = function () {
    //Phải Nhập password thì nút save mới hiện.
    if (document.getElementById('password').value != "") {
        document.getElementById('btn-save').removeAttribute('disabled');
    }
    else {
        document.getElementById('btn-save').setAttribute('disabled', 'false');
    }
}
$(function () {
    $(".start-place .dropdown-menu li a").click(function (e) {
        e.preventDefault();
        $('input[type=text].input-start-place').val($(this).text());
    });
    $(".end-place .dropdown-menu li a").click(function (e) {
        e.preventDefault();
        $('input[type=text].input-end-place').val($(this).text());
    });
    $(".time .dropdown-menu li a").click(function (e) {
        e.preventDefault();
        $('input[type=text].input-time').val($(this).text());
    });
})
/*SUGESTION*/
$(function () {
    var availableTags = [
        "ActionScript",
        "AppleScript",
        "Asp",
        "BASIC",
        "C",
        "C++",
        "Clojure",
        "COBOL",
        "ColdFusion",
        "Erlang",
        "Fortran",
        "Groovy",
        "Haskell",
        "Java",
        "JavaScript",
        "Lisp",
        "Perl",
        "PHP",
        "Python",
        "Ruby",
        "Scala",
        "Scheme"
    ];
    $("#input-start-place").autocomplete({
        source: availableTags
    });
    $("#input-end-place").autocomplete({
        source: availableTags
    });
});

/*DATEPICKER*/
$('#your-datepicker-id').datepicker({
    dateFormat: "dd/mm/yy",
})



/*MAP*/
function initMap() {
    // The location of Uluru
    const uluru = { lat: -25.344, lng: 131.036 };
    // The map, centered at Uluru
    const map = new google.maps.Map(document.getElementById("map"), {
        zoom: 4,
        center: uluru,
    });
    // The marker, positioned at Uluru
    const marker = new google.maps.Marker({
        position: uluru,
        map: map,
    });
}


/*JS FOR SEAT SELECTOR*/
const container = document.querySelector('.container');
const seats = document.querySelectorAll('.row .seat:not(.occupied)');
const count = document.getElementById('count');
const price = document.getElementById('price');
const count_in_form = document.getElementById('num_ticket');
const price_in_form = document.getElementById('total_price');
const list_seat = document.getElementById('list_seat');
var array = [];

const movieSelect = document.getElementById('movie');
let ticketPrice = +movieSelect.value
 ticketPrice = movieSelect.textContent;



const populateUI = () => {
    const selectedSeats = JSON.parse(localStorage.getItem('selectedSeats'));

    if (selectedSeats !== null && selectedSeats.length > 0) {
        seats.forEach((seat, index) => {
            if (selectedSeats.indexOf(index) > -1) {
                seat.classList.add('selected');
            }
        });
    }

    const selectedMovieIndex = localStorage.getItem('selectedMovieIndex');
    const selectedMoviePrice = localStorage.getItem('selectedMoviePrice');

    if (selectedMovieIndex !== null) {
        movieSelect.selectedIndex = selectedMovieIndex;
    }

    if (selectedMoviePrice !== null) {
        count.innerText = selectedSeats.length ;
        price.innerText = selectedSeats.length * +selectedMoviePrice;
    }
};

populateUI();

selectedMovie = (movieIndex, moviePrice) => {
    localStorage.setItem('selectedMovieIndex', movieIndex);
    localStorage.setItem('selectedMoviePrice', moviePrice);
};

const updateSelectedSeatsCount = () => {
    const selectedSeats = document.querySelectorAll('.row .selected');

    const seatsIndex = [...selectedSeats].map(seat => [...seats].indexOf(seat));
    localStorage.setItem('selectedSeats', JSON.stringify(seatsIndex));
    localStorage.clear();

    const selectedSeatsCount = selectedSeats.length;

    count_in_form.value = selectedSeatsCount;
    price_in_form.value = selectedSeatsCount * ticketPrice + ".000đ";
    setSeat(seatsIndex);
};

// Seat select event
container.addEventListener('click', e => {
    if (
        e.target.classList.contains('seat') &&
        !e.target.classList.contains('occupied')
    ) {
        if (e.target.classList.contains('selected')) {
            console.log(e.target.id);
            list_seat.value =  list_seat.value.replaceAll(e.target.id+',', '');
        }
        e.target.classList.toggle('selected');
        updateSelectedSeatsCount();
        if (e.target.classList.contains('selected')) {
            list_seat.value += e.target.id + ',';
        }
    }
});

// Movie select event
movieSelect.addEventListener('change', e => {
    ticketPrice = +e.target.value;
    selectedMovie(e.target.selectedIndex, e.target.value);

    updateSelectedSeatsCount();
});
var testSeat = function (pr) {
    //Phải Nhập password thì nút save mới hiện.
    pr = pr.trim();
    var a = document.getElementById(pr);
    if (a != null) {
        a.classList.add('occupied');
    }
}
$(function () {
            // When your page loads, create a delay (5s) to hide any errored elements
            setTimeout(function () { $('.validationSumary').fadeOut(); }, 2000);
        });


const setSeat = (list) => {
    list.forEach(item=> console.log(item-1));
    
};
