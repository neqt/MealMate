const path = require('path');

module.exports = {
  entry: './wwwroot/js/react/components/index.js',
  output: {
    path: path.resolve(__dirname, 'wwwroot/dist'),
    filename: 'bundle.js'
  },
  module: {
    rules: [
      {
        test: /\.js$/,
        exclude: /(node_modules)/,
        use: {
          loader: 'babel-loader'
        }
      }
    ]
  }
};
