<template>
  <el-card v-loading="uploading" style="width: fit-content" shadow="never">
    <input
      ref="fileInput"
      type="file"
      class="avatar-uploader"
      @change="handleFileUpload"
    >
    <el-image v-if="imageUrls" :src="imageUrls[0]" :preview-src-list="imageUrls" class="avatar" />
  </el-card>
</template>

<script>
import axios from 'axios'
import { cloudinaryConfig } from '../../cloudinaryConfig'
export default {
  data() {
    return {
      uploading: false,
      imageUrls: []
    }
  },
  methods: {
    openFileInput() {
      this.$refs.fileInput.click()
    },
    async handleFileUpload(event) {
      this.uploading = true
      console.log('hehe')
      const files = Array.from(event.target.files)

      const uploaders = files.map((file) => {
        const formData = new FormData()
        formData.append('file', file)
        formData.append('upload_preset', cloudinaryConfig.uploadPreset)
        return axios.post(cloudinaryConfig.apiUrl, formData, {
          headers: { 'Content-Type': 'multipart/form-data' }
        })
      })
      const results = await Promise.all(uploaders)
      const urls = results.map((res) => res.data.secure_url)
      this.imageUrls.push(...urls)
      this.$emit('image-uploaded', this.imageUrls) // emit the event with imageUrls
      this.uploading = false
    }
  }
}
</script>

<style scoped>
.avatar-uploader .el-upload {
  border: 1px dashed #d9d9d9;
  border-radius: 6px;
  cursor: pointer;
  position: relative;
  overflow: hidden;
}
.avatar-uploader .el-upload:hover {
  border-color: #409eff;
}
.avatar-uploader-icon {
  font-size: 28px;
  color: #8c939d;
  width: 178px;
  height: 178px;
  line-height: 178px;
  text-align: center;
}
.avatar {
  max-width: 300px;
  max-height: 300px;
  display: block;
  object-fit: cover;
}
</style>
