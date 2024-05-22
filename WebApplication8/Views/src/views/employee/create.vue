<template>
  <div class="app-container">
    <el-form ref="form" v-loading="loading" :model="form" label-width="200px">
      <el-form-item label="Employee Name">
        <el-input v-model="form.name" />
      </el-form-item>
      <el-form-item label="Employee Position">
        <el-input v-model="form.position" />
      </el-form-item>
      <el-form-item label="Work Email">
        <el-input v-model="form.workEmail" />
      </el-form-item>
      <el-form-item label="Birthday">
        <el-date-picker
          v-model="form.birthday"
          type="date"
          placeholder="Pick a day"
          value-format="yyyy-MM-dd"
        />
      </el-form-item>
      <el-form-item label="Phone Number">
        <el-input v-model="form.phoneNumber" />
      </el-form-item>
      <el-form-item label="Employee Type - Start Date">
        <el-select v-model="form.employeeType" placeholder="Select">
          <el-option
            v-for="item in employeeTypesOptions"
            :key="item.value"
            style="margin-left: 10px;"
            :label="item.label"
            :value="item.value"
          />
        </el-select>
        <el-date-picker
          v-model="form.joinDate"
          type="date"
          placeholder="Pick a day"
          value-format="yyyy-MM-dd"
        />
      </el-form-item>
      <el-form-item label="Department">
        <el-select v-model="form.departmentId" placeholder="Select">
          <el-option
            v-for="item in departmentsOptions"
            :key="item.value"
            style="margin-left: 10px;"
            :label="item.label"
            :value="item.value"
          />
        </el-select>
      </el-form-item>
      <el-form-item label="Avatar">
        <cloundinary-upload @image-uploaded="onImageUploaded" />
      </el-form-item>
      <el-form-item label="Status">
        <el-select v-model="form.status" placeholder="Select">
          <el-option
            v-for="item in employeeStatusOptions"
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
import CloundinaryUpload from '@/components/CloudinaryUpload'
import { getListDepartment } from '@/api/department'
import { createEmployee } from '@/api/employee'
import { EmployeeType } from '@/constant/index'
import moment from 'moment'
export default {
  components: {
    CloundinaryUpload
  },
  data() {
    return {
      loading: false,
      form: {
        name: '',
        position: '',
        workEmail: '',
        birthday: '',
        phoneNumber: '',
        employeeType: '',
        avatarUrl: '',
        departmentId: '',
        joinDate: '',
        status: 1
      },
      employeeTypesOptions: [
        { label: 'Full-time', value: EmployeeType.FULLTIME },
        { label: 'Part-time', value: EmployeeType.PARTTIME },
        { label: 'Intern', value: EmployeeType.INTERN }
      ],
      employeeStatusOptions: [
        { label: 'Active', value: 1 },
        { label: 'Inactive', value: 0 }
      ],
      departmentsOptions: [],
      listDepartment: []
    }
  },
  created() {
    this.onGetDepartments()
  },
  methods: {
    onImageUploaded(imageUrls) {
      this.form.avatarUrl = imageUrls[0]
    },
    onGetDepartments() {
      getListDepartment().then(response => {
        this.listDepartment = response.data
        this.departmentsOptions = response.data.map(item => {
          return {
            label: item.name,
            value: item.id
          }
        })
      })
    },
    onSubmit() {
      this.loading = true
      createEmployee({
        ...this.form,
        birthday: moment(this.form.birthday).format('DD/MM/YYYY'),
        joinDate: moment(this.form.joinDate).format('DD/MM/YYYY')
      }).then(response => {
        this.$message({
          message: 'Create success',
          type: 'success'
        })
        this.$router.push({ path: '/employee/list' })
      }).finally(() => {
        this.loading = false
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

