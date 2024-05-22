<template>
  <div class="app-container">
    <el-form ref="form" :model="form" label-width="120px">
      <el-form-item label="Deparment Name">
        <el-input v-model="form.name" required />
      </el-form-item>
      <el-form-item label="Description">
        <el-input v-model="form.description" type="textarea" required />
      </el-form-item>
      <el-form-item>
        <el-button type="primary" @click="onSubmit">Create</el-button>
        <el-button @click="onCancel">Cancel</el-button>
      </el-form-item>
    </el-form>
  </div>
</template>

<script>
import { createDepartment } from '@/api/department'
export default {
  data() {
    return {
      form: {
        name: '',
        description: ''
      }
    }
  },
  methods: {
    onSubmit() {
      createDepartment(this.form).then(response => {
        this.$message({
          message: 'Create success',
          type: 'success'
        })
        this.$router.push({ path: '/department/list' })
      })
    },
    onCancel() {
      this.$message({
        message: 'cancel!',
        type: 'warning'
      })
    }
  }
}
</script>

<style scoped>
.line{
  text-align: center;
}
</style>

