import request from '@/utils/request'

export function getListEmployee(params) {
  return request({
    url: '/Employee',
    method: 'get',
    params
  })
}

export function createEmployee(data) {
  return request({
    url: '/Employee',
    method: 'post',
    data
  })
}
