<template>
  <div class="app-container">
    <el-form ref="form" :model="form" label-width="120px">
      <el-form-item label="Blog Title">
        <el-input v-model="form.title" required />
      </el-form-item>
      <el-form-item label="Thumnail">
        <CloundinaryUpload @image-uploaded="onImageUploaded" />
      </el-form-item>
      <el-form-item label="Blog Content">
        <quillEditor
          ref="myQuillEditor"
          v-model="form.content"
          :options="editorOption"
          style="height: 450px;"
        />
      </el-form-item>
      <el-form-item label="Blog Type" style="margin-top: 75px">
        <el-select v-model="form.type" placeholder="Select">
          <el-option
            v-for="item in blogTypeOptions"
            :key="item.value"
            style="margin-left: 10px;"
            :label="item.label"
            :value="item.value"
          />
        </el-select>
      </el-form-item>
      <el-form-item>
        <el-button type="primary" @click="onSubmit">Create</el-button>
        <el-button @click="onCancel">Cancel</el-button>
      </el-form-item>
    </el-form>
  </div>
</template>

<script>
import 'quill/dist/quill.core.css'
import 'quill/dist/quill.snow.css'
import 'quill/dist/quill.bubble.css'
import { createPost } from '@/api/post'
import { quillEditor } from 'vue-quill-editor'
import CloundinaryUpload from '@/components/CloudinaryUpload'
export default {
  components: {
    quillEditor,
    CloundinaryUpload
  },
  data() {
    return {
      form: {
        title: '',
        content: '',
        createdAt: new Date(),
        thumbnailUrl: '',
        type: ''
      },
      editorOption: {
        debug: 'default',
        placeholder: 'Write your post here...',
        readOnly: true,
        theme: 'snow'
      },
      blogTypeOptions: [
        { value: 1, label: 'Company Information' },
        { value: 2, label: 'Company Work Schedule' }
      ]
    }
  },
  methods: {
    onSubmit() {
      createPost(this.form).then(response => {
        this.$message({
          message: 'Create success',
          type: 'success'
        })
        this.$router.push({ path: '/post/list' })
      })
    },
    onCancel() {
      this.$message({
        message: 'cancel!',
        type: 'warning'
      })
    },
    onImageUploaded(imageUrls) {
      this.form.thumbnailUrl = imageUrls[0]
    }
  }
}
</script>

<style scoped>
.line{
  text-align: center;
}
</style>

