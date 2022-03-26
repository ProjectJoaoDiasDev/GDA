import gulp from 'gulp';
import concat from 'gulp-concat';
import cssmin from 'gulp-cssmin';
import imagemin from 'gulp-imagemin';
import browserSync from 'browser-sync';

browserSync.create();

gulp.task('browser-sync', function () {
    browserSync.init({
        server: {
            baseDir: "./"
        }
    });
});

gulp.task('watch-css', function () {
    gulp.watch('./styles/**/*.css', ['css']);
})

gulp.task("js", function () {
    return gulp.src([
        './node_modules/bootstrap/dist/js/bootstrap.js',
        './node_modules/bootstrap/dist/js/bootstrap.js.map',
        './node_modules/bootstrap/dist/js/bootstrap.bundle.js',
        './node_modules/bootstrap/dist/js/bootstrap.bundle.js.map',
        './node_modules/@popperjs/core/dist/cjs/popper.js',
        './node_modules/@popperjs/core/dist/cjs/popper.js.map',
        './node_modules/jquery/dist/jquery.min.js',
        './node_modules/jquery-validation/dist/jquery.validate.js',
        './node_modules/jquery-validation/dist/jquery.validate.min.js',
        './node_modules/jquery-validation-unobtrusive/dist/jquery.validate.unobtrusive.min.js',
        './node_modules/jquery-ajax-unobtrusive/dist/jquery.unobtrusive-ajax.js',
        './node_modules/jquery.maskedinput/src/jquery.maskedinput.js',
        './node_modules/vue/dist/vue.global.js',
        './node_modules/toastr/build/toastr.min.js',
        './node_modules/toastr/build/toastr.js.map',
        './node_modules/@fortawesome/fontawesome-free/js/brands.js',
        './node_modules/@fortawesome/fontawesome-free/js/solid.js',
        './node_modules/@fortawesome/fontawesome-free/js/fontawesome.js',
        './node_modules/moment/min/moment.min.js',
        './node_modules/js-cookie/dist/js.cookie.js',
        './js/**/*.js'
    ]).pipe(gulp.dest('wwwroot/js/'));
});

gulp.task("css", function () {
    return gulp.src([
        './node_modules/@fortawesome/fontawesome-free/css/all.css',
        './node_modules/bootstrap/dist/css/bootstrap.css',
        './node_modules/toastr/build/toastr.min.css',
        './styles/**/*.css'
    ])
        .pipe(concat('site.css'))
        .pipe(cssmin())
        .pipe(gulp.dest('wwwroot/css/'));
});

gulp.task("img", function () {
    return gulp.src('./images/**/*')
        .pipe(imagemin())
        .pipe(gulp.dest('wwwroot/images/'));
});

gulp.task('font', function () {
    return gulp.src([
        './fonts/**/*',
        './node_modules/@fortawesome/fontawesome-free/webfonts/*'
    ]).pipe(gulp.dest('wwwroot/webfonts/'));
});