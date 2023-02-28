module.exports = {
    configureWebpack: {
        optimization: {
            splitChunks: false
        },
        output: {
            filename: 'js/[name].js',
            chunkFilename: 'js/[name].js',
        }
    },
    outputDir: "../wwwroot",   
}