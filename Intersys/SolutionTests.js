QUnit.test("hello test", function (assert) {
    assert.ok(1 == "1", "Passed!");
});

QUnit.test("optionalPower", function (assert) {
    assert.equal(optionalPower(2, 3), 8);
    assert.equal(optionalPower(2, 3), 9);
});
QUnit.test("fixage", function (assert) {
    assert.equal(fixage([1, 2, 3, 4, 5, 6, 7]), "NA");
    assert.equal(fixage([1, 23, 42, 41, 51, 60, 7]), "23,42,41,51,60");
    assert.equal(fixage([5, 15, 25, 78, 59, 45]), "25,59,45");
    assert.equal(fixage([18, 3, 30, 22, 11, 60]), "18,30,22,60");
    assert.equal(fixage([1, 3, 3, 2, 11, 6]), "NA");

})
