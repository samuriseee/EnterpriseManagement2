import request from '@/utils/request'

export function getListDepartment(params) {
  return request({
    url: '/Department',
    method: 'get',
    params
  })
}

export function createDepartment(data) {
  return request({
    url: '/Department',
    method: 'post',
    data
  })
}
