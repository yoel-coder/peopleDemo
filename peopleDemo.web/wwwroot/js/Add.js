console.log("hello")
$(() => {
    console.log("hello")
    let num = 0

    $('input').on("input", function () {
        ensureFormValidity();
    })
    $("#add-rows").on("click", function () {
        
        num++
        console.log("hello");
        $("#AddForm").append(`
        <div class="row person-row" style="margin-bottom: 10px;">
            <div class="col-md-4">
                                    <input class="form-control" type="text" name="people[0].firstname" placeholder="First Name" fdprocessedid="ml557" id="firstName">
                                </div>
                                <div class="col-md-4">
                                    <input class="form-control" type="text" name="people[0].lastname" placeholder="Last Name" fdprocessedid="6ev6kt"id="lastname">
                                </div>
                                <div class="col-md-4">
                                    <input class="form-control" type="text" name="people[0].age" placeholder="Age" fdprocessedid="x0ujxs"id="age">
                                </div>
        </div>`)

    })

    function ensureFormValidity() {
        const firstname = $("#firstName").val().trim();
        const lastname = $("#lastname").val().trim();
        const age = $("#age").val().trim();
       
       
        const isfirstValid = Boolean(firstname)
        const isLastnamelValid = Boolean(lastname)
        const isAgeValid = Boolean(age);
        
        const valid = isAgeValid && isfirstValid && isLastnamelValid&&!isNaN(age);
        $("#submit-button").prop('disabled', !valid)
    }




})