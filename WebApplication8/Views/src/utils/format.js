export const formatDate = (date, format) => {
  return format.replace(/(y+|M+|d+|H+|m+|s+)/g, (match) => {
    switch (match.charAt(0)) {
      case 'y':
        return date.getFullYear()
      case 'M':
        return date.getMonth() + 1
      case 'd':
        return date.getDate()
      case 'H':
        return date.getHours()
      case 'm':
        return date.getMinutes()
      case 's':
        return date.getSeconds()
      default:
        return ''
    }
  }
  )
}
