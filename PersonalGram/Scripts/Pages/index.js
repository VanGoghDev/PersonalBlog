var app = new Vue({
    el: '#app',
    data: {
        firstMessageDate: getDatesDiff(new Date(2017, 6, 18, 23,59)),
        datingDiff: getDatesDiff(new Date(2017, 8, 10))
    }
})

// Counts difference between date and current day
function getDatesDiff(date) {
    let today = new Date()
    const diffTime = Math.abs(today - date);
    return Math.ceil(diffTime / (1000 * 60 * 60 * 24))
}

// If you need to convert date to a specific format 
function formatDate(date) {
    var d = new Date(date),
        month = '' + (d.getMonth() + 1),
        day = '' + d.getDate(),
        year = d.getFullYear();

    if (month.length < 2)
        month = '0' + month;
    if (day.length < 2)
        day = '0' + day;

    return [day, month, year].join('-');
}