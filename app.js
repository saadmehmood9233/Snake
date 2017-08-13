var express = require("express");
var bodyParser = require('body-parser');
var fs = require('fs');
const path = require('path');
var exec = require('child_process').execFile;

var app = express();

app.use(bodyParser.json());

app.set('view engine', 'ejs');

app.use('/public', express.static('public'));
app.use('/assets', express.static('assets'));

app.get("/", function (req, res) {
    res.render("pages/index", {style: 'snake.css'});
});


app.post("/api/compile", function(req, res) {

    fs.writeFile('Hello.cs', req.body.code, function (err) {
        if (err) throw err;
        console.log('File Created');
    });

    var absolutepath = path.resolve("./Hello.cs");

    const { spawn } = require('child_process');
    const bat = spawn('cmd.exe', ['/c csc ' + absolutepath]);

    bat.stdout.on('data', function(data) {
        console.log(data.toString());
    });

    bat.stderr.on('data', function(data) {
        console.log(data.toString());
    });

    bat.on('exit', function(code){
        console.log('Child exited with code ${code}');
    });

    var absolutepath2 = path.resolve("./Hello.exe");

    exec(absolutepath2, function(err, data) {
            console.log(err);
            res.json({error: false, data: data.toString()});
    });

});


app.listen("3000", function () {
    console.log("Listening at: http://localhost:3000");
});