const shell = require('shelljs')
const colors = require('colors')

;(async () => {
  console.log('deployment started!'.blue)
  stopInstance('api1')
  await seconds(30)
  startInstance('api1')
  await seconds(30)
  stopInstance('api2')
  await seconds(30)
  startInstance('api2')
  console.log('deployment completed!'.blue)
})()

function stopInstance (instance) {
  console.log(`stopping ${instance}`.green)
  if (shell.exec(`docker-compose stop ${instance}`).code !== 0) {
    shell.echo(`Error: could not stop ${instance}`)
    shell.exit(1)
  }
}

function startInstance (instance) {
  console.log(`starting ${instance}`.green)
  if (shell.exec(`docker-compose up -d --build ${instance}`).code !== 0) {
    shell.echo(`Error: could not start ${instance}`)
    shell.exit(1)
  }
}

function seconds (i) {
  console.log(`sleeping for ${i} seconds`.yellow)
  return new Promise((resolve, reject) => {
    setTimeout(resolve, i * 1000)
  })
}
