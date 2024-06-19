module.exports = env => {
    // Use the default cluu webpack config.
    let buildConfig = require(env.cluuWebPackConfig)(env, module, __dirname);

    if (buildConfig.webPackConfig.context == null) {
        buildConfig.webPackConfig.context = __dirname + "/dist";
    }
    // Default for buildConfig.webPackConfig:
    // --------------------------------------
    // mode: <configuration>,
    // entry: { '<bundleName>': './src/_bundles/<bundleName>' },
    // output: {
    //   libraryTarget: "amd",
    //   filename: '<bundleName>.js',
    //   path: '/dist'
    //   devtoolNamespace: '<projectName>'
    // },
    // devtool: 'source-map',
    // externals: [<cluuExternalsFunc>],
    // resolve: { extensions: ['.js'] }

    return buildConfig.webPackConfig;
};
