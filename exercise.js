const request = require('superagent')
const colors = require('colors')

setInterval(() => {
  request.get('localhost/demo').end(function (err, res) {
    if (err) {
      console.log(err.toString().red)
    } else {
      console.log(
        `localhost/demo returned a ${res.status} with text: ${res.text} ${new Date()
          .toTimeString()
          .split(' ')[0]} `.green
      )
    }
  })
}, 1000)
