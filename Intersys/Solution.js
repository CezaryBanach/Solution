function optionalPower(a, b) {
    if (confirm("OK")) {
        return Math.pow(a, b);
    }
    else {
        return Math.pow(b, a);
    }
}

function fixage(ages) {
    let res = "";
    for (var i = 0; i < ages.length; i++) {
        let age = ages[i];
        if (age >= 18 && age <= 60)
            res += age+",";
    }
    if (res == "")
        return "NA";
    if (res[res.length - 1] == ",")
        res = res.substring(0, res.length - 1);
    return res;
}
