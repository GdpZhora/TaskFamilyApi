function GetBudgetStatus() {
    $("div[id = 'budget']").empty();

    $.ajax({
        type: "GET",
        url: "Budget/JSTotal",
        cache: false,
        success: function (total) {
            $("div[id = 'budget']").append($("<h1></h1>").text("Финансовое состояние " + total));
        }
    }
    );
}

function GetTodoStatus() {
    $("div[id = 'Todo']").empty();

    $("div[id = 'Todo']").append($("<h1></h1>").text("Задачи"));

    $("div[id = 'Todo']").append("Текущие задачи в работе - ");
    $("div[id = 'Todo']").append($("<a></a>").text("4").attr("href", "/todo/work").attr("class", "navbar-brand"));
    //append(.add(("4"));

}
