const {createProxyMiddleware} = require('http-proxy-middleware');

const context = [
    "/api/Start"
];

module.exports = function (app) {
    const appProxy = createProxyMiddleware(context, {
        target: 'http://localhost:5247',
        //target: 'https://localhost:80',
        secure: false
    });

    app.use(appProxy);
};
