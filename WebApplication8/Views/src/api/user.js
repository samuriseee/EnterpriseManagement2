import request from '@/utils/request'

export function login(data) {
  return request({
    url: '/Account/signin',
    method: 'post',
    data
  })
}

export function getInfo(token) {
  return request({
    url: '/vue-admin-template/user/info',
    method: 'get',
    params: { token }
  })
}

export function logout() {
  return request({
    url: '/account/logout',
    method: 'post'
  })
}
