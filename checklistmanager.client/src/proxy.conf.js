const { env } = require('process');

const target = 'https://localhost:7228';

const PROXY_CONFIG = [
  {
    context: [
      "/checklist",
      "/vehicle"
    ],
    target,
    secure: true
  }
]

module.exports = PROXY_CONFIG;
