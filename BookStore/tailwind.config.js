/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    './Views/**/*.cshtml',
    './Views/*.cshtml',
      './Areas/Admin/**/*.cshtml',
    './Areas/Customer/**/*.cshtml',
    "./node_modules/flowbite/**/*.js"
  ],
  theme: {
    extend: {},
  },
  plugins: [
    require('flowbite/plugin')({
      datatables: true,
    }),
  ],
}

