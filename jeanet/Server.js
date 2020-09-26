var app = require('express')();
var http = require('http').createServer(app);
var io = require('socket.io')(http);

app.get('/', function(req, res){
    res.json({
        Product: 'JeaNet Server',
        Version: '2.1'
    })
});

app.get('/debug', function(req, res){
    res.sendFile(__dirname + '/index.html');
});


io.on('connection', (socket) => {
    console.log('[General] Usuario Conectado');

    socket.on('userLocation', (UserLocation) => {
        io.emit('newUserLocation', UserLocation)
        console.log('[Ubicacion] UserLocation:', UserLocation)
    })
});

http.listen(3000, () => {
  console.log('[General] Servidor Corriendo en *:3000');
});