module.exports = (env, parentModule, __parentDirname) => {
    let globalModulesPaths = null;
    let configuration = null;
    let projectName = null;
    let bundleNames = null;
    let cluuCustomWebPackConfigPaths = null;
    let isVsCodeEnvironment = null;

    if (env !== null) {
        if (env.globalModulesPaths !== null) {
            globalModulesPaths = env.globalModulesPaths;
        }

        if (env.configuration !== null) {
            configuration = env.configuration;
        }

        if (env.projectName !== null) {
            projectName = env.projectName;
        }

        if (env.bundleNames !== null) {
            bundleNames = env.bundleNames;
        }
        else {
            bundleNames = projectName;
        }

        if (env.isVsCodeEnvironment) {
            isVsCodeEnvironment = env.isVsCodeEnvironment.toLowerCase() == "true";
        }

        if (env.cluuCustomWebPackConfigPaths !== null) {
            cluuCustomWebPackConfigPaths = env.cluuCustomWebPackConfigPaths;
        }

        if (env.ignoreExternal == null) {
            env.ignoreExternal = [];
        }
    }

    console.info("Environment: ");
    console.info("- globalModulesPaths: " + globalModulesPaths);
    console.info("- configuration: " + configuration);
    console.info("- projectName: " + projectName);
    console.info("- bundleNames: " + bundleNames);
    console.info("- isVsCodeEnvironment: " + isVsCodeEnvironment);
    console.info("- cluuCustomWebPackConfigPaths: " + cluuCustomWebPackConfigPaths);

    if (globalModulesPaths !== null) {
        module.paths.push(globalModulesPaths);
        parentModule.paths.push(globalModulesPaths);
    }

    let bundles = bundleNames.split(";");

    let buildConfig = {
        webPackConfig: createDefaultWebpackConfig(env, __parentDirname, configuration, bundles, projectName, isVsCodeEnvironment),
        configuration: configuration,
        projectName: projectName
    };

    if (cluuCustomWebPackConfigPaths != null) {
        let cluuCustomWebPackConfigs = cluuCustomWebPackConfigPaths.split(";");

        for (let i = 0; i < cluuCustomWebPackConfigs.length; i++) {
            require(cluuCustomWebPackConfigs[i])(env, buildConfig);
        }
    }

    return buildConfig;
};

function createDefaultWebpackConfig(env, __parentDirname, configuration, bundles, projectName, isVsCodeEnvironment) {
    let isDebug = configuration === "Debug";
    let mode = isDebug ? "development" : "production";

    let entries = {};
    for (let i = 0; i < bundles.length; i++) {
        let bundleName = bundles[i];
        entries[bundleName] = "./src/_bundles/" + bundleName;
    }

    const result = {
        mode: mode,

        entry: entries,

        output: {
            libraryTarget: "amd",
            filename: "[name].js",
            path: __parentDirname + "/dist",
            devtoolNamespace: projectName
        },

        devtool: "source-map",

        externals: [
            ({context, request}, callback) => {
                let regex = /^[^.].*$/;

                if (regex.test(request)) {
                    let shouldIgnore = env != null
                        && env.ignoreExternal != null
                        && env.ignoreExternal.some(x => x(request));

                    if (!shouldIgnore) {
                        return callback(null, request);
                    }
                }

                callback();
            }
        ],

        resolve: {
            extensions: [".js"],
            modules: []
        }
    };
    
    if(isVsCodeEnvironment) {
        result.context = __parentDirname;
        result.devtool = "inline-source-map";
        result.module = {
            rules: [
                {
                    test: /\.tsx?$/,
                    use: [
                        {
                            loader: 'ts-loader',
                            options: {
                                transpileOnly: true
                            }
                        }
                    ]
                },
            ],
        };
        result.resolve.extensions.push(".ts");
    }

    return result;
}
