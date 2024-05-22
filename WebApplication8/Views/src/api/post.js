import request from '@/utils/request'

export function getListPost(params) {
  return request({
    url: '/Post',
    method: 'get',
    params
  })
}

export function createPost(data) {
  return request({
    url: '/Post',
    method: 'post',
    data
  })
}

export function updatePost(data) {
  return request({
    url: '/Post',
    method: 'put',
    data
  })
}

export function getPostDetail(id) {
  return request({
    url: `/Post/${id}`,
    method: 'get'
  })
}
