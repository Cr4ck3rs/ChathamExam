const gulp = require('gulp');

gulp.task('fonts', fonts);

function fonts() {
  return gulp.src([
    'bower_components/bootstrap-sass/assets/fonts/bootstrap/**.*'])
    .pipe(gulp.dest('dist/fonts/bootstrap'));
}
